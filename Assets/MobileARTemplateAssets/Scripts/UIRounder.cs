using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class RoundEdgeImage : MonoBehaviour
{
    public float edgeRadius = 10f; // Variable to adjust the edge radius in the editor

    public Image image; // Reference to the Image component

    void Start()
    {
        // Set the image's material to a rounded corner material
        image.material = new Material(Shader.Find("UI/Unlit/RoundEdgeShader"));

        // Apply the edge radius to the shader
        ApplyEdgeRadius();
    }

    // Function to apply the edge radius to the shader
    void ApplyEdgeRadius()
    {
        // Ensure that the image component and its material exist
        if (image != null && image.material != null)
        {
            // Set the edge radius parameter in the shader
            image.material.SetFloat("_EdgeRadius", edgeRadius);
        }
    }

#if UNITY_EDITOR
    // This function is called when a value is changed in the editor
    void OnValidate()
    {
        // Ensure that the image component exists
        if (image != null)
        {
            // Apply the edge radius to the shader when the value changes in the editor
            ApplyEdgeRadius();
        }
    }
#endif
}
