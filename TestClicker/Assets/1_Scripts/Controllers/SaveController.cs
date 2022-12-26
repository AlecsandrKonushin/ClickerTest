using System;
using System.IO;
using Logs;
using SaveSystem;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "SaveController", menuName = "Controllers/SaveController")]
    public class SaveController : BaseController
    {
        public const string PATH_SAVE = "/SaveGame.json";

        private SaveData saveData;

        public bool IsHaveSave { get => saveData != null; }

        public int GetMoneyPlayer { get => saveData.MoneyPlayer; }
        public SaveBusinessData[] GetBusinessData { get => saveData.BusinessData; }

        public override void OnInitialize()
        {
            Load();
        }

        public void Load()
        {
            try
            {
                if (File.Exists(Application.persistentDataPath + PATH_SAVE))
                {
                    string strLoadJson = File.ReadAllText(Application.persistentDataPath + PATH_SAVE);
                    saveData = JsonUtility.FromJson<SaveData>(strLoadJson);
                }
            }
            catch (Exception ex)
            {
                LogManager.Instance.LogError($"Error load save - {ex}");
            }
        }

        public void Save()
        {
            saveData = new SaveData(BoxControllers.GetController<MoneyController>().MoneyPlayer,
                                    BoxControllers.GetController<BusinessController>().Businesses);

            string jsonString = JsonUtility.ToJson(saveData);

            try
            {
                File.WriteAllText(Application.persistentDataPath + PATH_SAVE, jsonString);
            }
            catch (Exception ex)
            {
                LogManager.Instance.LogError($"Error save - {ex}");
            }
        }

        private void OnApplicationFocus(bool focus)
        {
            if (!focus)
            {
                Save();
            }
        }
    }
}