using UnityEngine;
using System.Collections;

	public class RaycastShooter : MonoBehaviour {

		public LayerMask layers;
		public float force = 10000f;
		public ParticleSystem blood;

        // Update is called once per frame
        void Update () {
			if (Input.GetMouseButtonDown(0)) {
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

				// Raycast to find a ragdoll collider
				RaycastHit hit = new RaycastHit();
				if (Physics.Raycast(ray, out hit, 100f, layers)) {
					var broadcaster = hit.collider.attachedRigidbody;

					if (broadcaster != null) {
						broadcaster.AddForce(ray.direction * force);
                        

						blood.transform.position = hit.point;
						blood.transform.rotation = Quaternion.LookRotation(-ray.direction);
						blood.Emit(5);
					}
				}
			}
		
	}
}
