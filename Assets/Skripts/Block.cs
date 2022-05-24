using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(MeshRenderer))]

public class Block : MonoBehaviour
{
    [SerializeField] private ParticleSystem _destroyEffect;
    private MeshRenderer _meshRenderer;
    public event UnityAction<Block> BulletHit;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }


    public void SetColor (Color color)
    {
        _meshRenderer.material.color = color;
    }
    public void Break()
    {
        BulletHit?.Invoke(this);        // вызов события у этого блока
        ParticleSystemRenderer renderer = Instantiate(_destroyEffect, transform.position + new Vector3(0,-0.5f,0), _destroyEffect.transform.rotation).GetComponent<ParticleSystemRenderer>();
        renderer.material.color = _meshRenderer.material.color;
        Destroy(gameObject);            // уничтожение блока
    }
}
