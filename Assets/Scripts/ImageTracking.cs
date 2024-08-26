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
        imageManager = FindObjectOfType<ARTrackedImageManager>();

        foreach (GameObject _preFab in placeablePreFabs)
        {
            GameObject _newPrefab = Instantiate(_preFab, Vector3.zero, Quaternion.identity);
            _newPrefab.name = _preFab.name;
            spawnerPreFabs.Add(_newPrefab.name, _newPrefab);
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
            spawnerPreFabs[image.name].SetActive(false);
        }
    }

    private void UpdateImage(ARTrackedImage image)
    {
        string name = image.referenceImage.name;
        //Vector3 _position = image.transform.position;

        GameObject preFab = spawnerPreFabs[name];
        //preFab.transform.position = _position;
        preFab.SetActive(true);

        foreach (GameObject go in spawnerPreFabs.Values)
        {
            if (go.name != name)
            {
                go.SetActive(false);
            }
        }
    }
}