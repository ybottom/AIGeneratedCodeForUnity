using UnityEngine;

public class ConvertToRagdoll : MonoBehaviour
{
    [MenuItem("Tools/Convert to Ragdoll")]
    private static void CreateRagdoll()
    {
        // Get the selected game object in the hierarchy
        GameObject selectedObject = Selection.activeGameObject;

        // Get the skinned mesh renderer and animator components
        SkinnedMeshRenderer skinnedMeshRenderer = selectedObject.GetComponent<SkinnedMeshRenderer>();
        Animator animator = selectedObject.GetComponent<Animator>();

        // Create a new game object for the ragdoll
        GameObject ragdoll = new GameObject(selectedObject.name + "_Ragdoll");

        // Add a rigidbody component to the ragdoll
        Rigidbody rigidbody = ragdoll.AddComponent<Rigidbody>();

        // Disable the collider on the original object
        Collider collider = selectedObject.GetComponent<Collider>();
        collider.enabled = false;

        // Create a new character joint for each bone in the original object's skeleton
        foreach (Transform boneTransform in animator.GetBoneTransforms())
        {
            // Create a new game object for the bone and set its position and rotation to match the original bone
            GameObject bone = new GameObject(boneTransform.name);
            bone.transform.parent = ragdoll.transform;
            bone.transform.position = boneTransform.position;
            bone.transform.rotation = boneTransform.rotation;

            // Add a rigidbody component to the bone
            Rigidbody boneRigidbody = bone.AddComponent<Rigidbody>();

            // Add a character joint component to the bone and set its anchor and connected anchor to the bone's position
            CharacterJoint characterJoint = bone.AddComponent<CharacterJoint>();
            characterJoint.anchor = Vector3.zero;
            characterJoint.connectedAnchor = Vector3.zero;

            // Set the bone's rigidbody as the connected body for the character joint
            characterJoint.connectedBody = boneRigidbody;
        }

        // Set the skinned mesh renderer and animator components to disabled
        skinnedMeshRenderer.enabled = false;
        animator.enabled = false;

        // Set the ragdoll as the parent of the original object
        selectedObject.transform.parent = ragdoll.transform;
    }
}
