using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    private Camera mainCamera;
    private Collider bladeCollider;
    private TrailRenderer bladeTrail;
    public GameManager gameManager;
    private bool slicing;

    public Vector3 direction {  get; private set; }
    public float sliceForce = 5f;
    public float minSliceVelocity = 0.01f;

    private float lastSliceTime;
    private List<Fruit> slicedFruits = new List<Fruit>();

    private void Awake()
    {
        mainCamera = Camera.main;
        bladeCollider = GetComponent<Collider>();
        bladeTrail = GetComponentInChildren<TrailRenderer>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnEnable()
    {
        StopSLicing();
    }

    private void OnDisable()
    {
        StopSLicing();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartSlicing();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopSLicing();
        }
        else if (slicing)
        {
            ContinueSlicing();
        }
    }

    private void StartSlicing()
    {
        Vector3 newPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0f;

        transform.position = newPosition;

        slicing = true;
        bladeCollider.enabled = true;
        bladeTrail.enabled = true;
        bladeTrail.Clear();
    }

    private void StopSLicing()
    {
        if (slicedFruits.Count > 0)
        {
            gameManager.IncreaseScore(slicedFruits.Count);
        }
        slicedFruits.Clear();
        slicing = false;
        bladeCollider.enabled = false;
        bladeTrail.enabled = false;
    }

    private void ContinueSlicing()
    {
        Vector3 newPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0f;

        direction = newPosition - transform.position;

        float velocity = direction.magnitude / Time.deltaTime;
        bladeCollider.enabled = velocity > minSliceVelocity;

        transform.position = newPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fruit"))
        {
            Fruit fruit = other.GetComponent<Fruit>();

            if (fruit != null)
            {
                float currentTime = Time.time;

                if (currentTime - lastSliceTime <= 0.1f)
                {
                    slicedFruits.Add(fruit);
                }
                else
                {
                    if (slicedFruits.Count > 0) // Check if there were fruits in the previous combo
                    {
                        gameManager.IncreaseScore(slicedFruits.Count); // Call IncreaseScore with previous combo count
                    }
                    slicedFruits.Clear();
                    slicedFruits.Add(fruit);
                }

                lastSliceTime = currentTime;
                fruit.Slice(direction, transform.position, sliceForce);
            }
        }
    }

    public void ClearCombo()
    {
        slicedFruits.Clear();
    }
}
