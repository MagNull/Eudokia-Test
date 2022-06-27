    using TMPro;
using UnityEngine;

namespace Sources.Runtime
{
    public class RecordsView : MonoBehaviour
    {
        [SerializeField]
        private int _recordsCount;
        [SerializeField]
        private GameObject _recordPanelPrefab;
        [SerializeField]
        private Transform _recordsTable;

        public void OnEnable()
        {
            LoadRecords();
        }

        private void LoadRecords()
        {
            foreach (Transform child in _recordsTable)
                Destroy(child.gameObject);

            SaveLoad.Load();
            var records = SaveLoad.Records;
            if(records.Count <= 0)
                return;

            for (var i = 0; i < records.Count && i < _recordsCount; i++)
            {
                Instantiate(_recordPanelPrefab, _recordsTable)
                    .GetComponentInChildren<TextMeshProUGUI>().text = records[i].ToString();
            }
        }
    }
}