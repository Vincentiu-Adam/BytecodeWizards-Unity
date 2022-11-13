using UnityEngine;

public class VFXRepository
{
    private const string VFX_FOLDER         = "VFX";
    private const string VFX_PREFAB_NAME    = "vfxs";

    private ParticleSystem[] particles;

    public VFXRepository()
    {
        //load all prefabs in vfx folder
        ParticleSystem[] particlePrefabs = Resources.LoadAll<ParticleSystem>(VFX_FOLDER);

        //create vfx object and instantiate all vfx there
        GameObject vfxParentObject = new GameObject(VFX_PREFAB_NAME);

        Transform vfxParent = vfxParentObject.transform;

        particles = new ParticleSystem[particlePrefabs.Length];
        for (int i = 0; i < particlePrefabs.Length; i++)
        {
            ParticleSystem particleSystem = Object.Instantiate(particlePrefabs[i], vfxParent, false);
            particleSystem.name = particlePrefabs[i].name;

            particles[i] = particleSystem;
        }
    }

    public ParticleSystem GetParticleSystem(int id)
    {
        if (id < 0 || id > particles.Length)
        {
            return particles[0]; //return first particle system if invalid id
        }

        return particles[id];
    }
}
