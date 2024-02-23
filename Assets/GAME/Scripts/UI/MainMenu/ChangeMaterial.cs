using UnityEngine;

public class ChangeMatertial: MonoBehaviour
{
    [SerializeField] SkinnedMeshRenderer meshrRendererToUse;
    [SerializeField] MeshRenderer weaponMeshRendererToUse;
    public Material[] materialToUse;
    public int matIndexOfPants = 0;
    public int matIndexOfWeapon = 0;   
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    ChangeMaterialOnMesh();
        //}
    }
    public void ChangeMaterialOnMesh()
    {
        if (matIndexOfPants < materialToUse.Length)
        {
            meshrRendererToUse.material = materialToUse[matIndexOfPants];
            Debug.Log(matIndexOfPants);
            matIndexOfPants++;
        }
        else
        {
            matIndexOfPants = 0;
        }
    }
    public void ChangeWeaponMaterialOnMesh()
    {
        if (matIndexOfWeapon < materialToUse.Length)
        {
            weaponMeshRendererToUse.material = materialToUse[matIndexOfWeapon];
            Debug.Log(matIndexOfWeapon);
            matIndexOfWeapon++;
        }
        else
        {
            matIndexOfWeapon = 0;
        }
    }
}
