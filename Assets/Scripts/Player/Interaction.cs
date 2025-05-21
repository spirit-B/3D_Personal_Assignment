using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Interaction : MonoBehaviour
{
	private float checkRate = 0.05f;
	private float lastCheckTime;
	private float maxCheckDistance = 3;
	public LayerMask layerMask;

	public GameObject curInteractObj;
	private IInteractable curInteractable;

	public TextMeshProUGUI promptText;
	private new Camera camera;

	// Start is called before the first frame update
	void Start()
	{
		camera = Camera.main;
	}

	// Update is called once per frame
	void Update()
	{
		if (Time.time - lastCheckTime > checkRate)
		{
			lastCheckTime = Time.time;

			Ray checkRay = camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
			RaycastHit hit;

			if (Physics.Raycast(checkRay, out hit, maxCheckDistance, layerMask))
			{
				if (hit.collider.gameObject != curInteractObj)
				{
					curInteractObj = hit.collider.gameObject;
					curInteractable = hit.collider.GetComponent<IInteractable>();
					SetPromptText();
				}
			}
			else
			{
				curInteractObj = null;
				curInteractable = null;
				promptText.gameObject.SetActive(false);
			}
		}
	}

	private void SetPromptText()
	{
		promptText.gameObject.SetActive(true);
		promptText.text = curInteractable.InteractPrompt();
	}
}
