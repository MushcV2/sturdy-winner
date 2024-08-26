using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARTrackedImageManager))]
public class ImageTracking : MonoBehaviour
{
    [SerializeField] private GameObject[] placeablePreFabs;

    private Dictionary<string, GameObject> spawnerPreFabs = new Dictionary<string, GameObject>();
    private ARTrackedImageManager imageManager;

    private void Awake()
    {
        imageManager = GetComponent<ARTrackedImageManager>();

        foreach (GameObject _preFab in placeablePreFabs)
        {
            GameObject _newPrefab = Instantiate(_preFab, Vector3.zero, Quaternion.identity);
            _newPrefab.name = _preFab.name;
            spawnerPreFabs[_newPrefab.name] = _newPrefab;
        }
    }

    private void OnEnable()
    {
        imageManager.trackedImagesChanged += ImageChanged;
    }

    private void OnDisable()
    {
        imageManager.trackedImagesChanged -= ImageChanged;
    }

    private void ImageChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach (ARTrackedImage image in args.added)
        {
            UpdateImage(image);
        }
        foreach (ARTrackedImage image in args.updated)
        {
            UpdateImage(image);
        }
        foreach (ARTrackedImage image in args.removed)
        {
            if (spawnerPreFabs.ContainsKey(image.referenceImage.name))
            {
                spawnerPreFabs[image.referenceImage.name].SetActive(false);
            }
        }
    }

    private void UpdateImage(ARTrackedImage image)
    {
        string name = image.referenceImage.name;

        if (spawnerPreFabs.ContainsKey(name))
        {
            GameObject preFab = spawnerPreFabs[name];
            preFab.SetActive(true);

            foreach (GameObject go in spawnerPreFabs.Values)
            {
                if (go.name != name)
                {
                    go.SetActive(false);
                }
            }
        }
        else
        {
            Debug.LogWarning($"Prefab with name '{name}' not found in the dictionary.");
        }
    }
}