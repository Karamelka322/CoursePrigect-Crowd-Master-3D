using UnityEngine;

public class SimpleFilter : MonoBehaviour
{
    [SerializeField] private Shader _shader;

    protected Material _mat;

    private bool _useFilter = true;

    private void Awake()
    {
        _mat = new Material(_shader);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.F))
            _useFilter = !_useFilter;

        OnUpdate();
    }

    protected virtual void OnUpdate() { }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (_useFilter)
            UseFilter(source, destination);
        else
            Graphics.Blit(source, destination);
    }

    protected virtual void UseFilter(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, _mat);
    }
}
