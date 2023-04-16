using UnityEngine;

public class AutoAimShooter : MonoBehaviour
{
    public LayerMask targetMask; // warstwa obiektów, które chcemy atakowaæ
    public float fireRate = 1f; // czêstotliwoœæ strzelania
    public float shootingRange = 10f; // zasiêg widzenia
    public float shootingForce; 
    public GameObject bulletPrefab; // prefabrykat pocisku

    public Material targetedMaterial; // materia³ dla celu, który jest aktualnie namierzany
    public Material defaultMaterial;
    private Transform currentTarget;

    private float nextFireTime; // czas nastêpnego strza³u

    public Camera cam;

    private void Update()
    {
        // Pobieramy wszystkie obiekty z warstwy celów, które s¹ w zasiêgu widzenia
        Collider[] targets = Physics.OverlapSphere(transform.position, shootingRange, targetMask);

        // Jeœli nie ma ¿adnych celów, to nie robimy nic
        if (targets == null || targets.Length == 0)
        {
            return;
        }

        Transform newTarget = targets[Random.Range(0, targets.Length)].transform;

        // Jeœli nowy cel jest ró¿ny od bie¿¹cego, to przywracamy domyœlny materia³ dla bie¿¹cego celu
        if (newTarget != currentTarget && currentTarget != null)
        {
            SetDefaultMaterial(currentTarget);
        }

        // Ustawiamy nowy cel jako bie¿¹cy cel
        currentTarget = newTarget;

        // Sprawdzamy, czy bie¿¹cy cel jest w zasiêgu widzenia i czas strzelania zosta³ osi¹gniêty
        if (IsTargetInRange(currentTarget) && Time.time >= nextFireTime )
        {

            SetTargetedMaterial(currentTarget);


            if (Input.GetKeyDown(KeyCode.Z))
            {
                // Obracamy siê w kierunku bie¿¹cego celu
                transform.LookAt(currentTarget);

                // Strzelamy
                Shoot();

                // Ustawiamy czas nastêpnego strza³u
                nextFireTime = Time.time + 1f / fireRate;
            }

        }

        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, currentTarget.position - cam.transform.position, out hit, shootingRange, targetMask))
        {
            
        }
        else
        {
            Debug.DrawLine(cam.transform.position, currentTarget.position, Color.green);
        }
    }

    private void SetTargetedMaterial(Transform target)
    {
        // Przywracamy domyœlny materia³ dla poprzedniego celu
        if (currentTarget != null && currentTarget != target)
        {
            Renderer renderer = currentTarget.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material = defaultMaterial;
            }
        }

        // Zmieniamy materia³ dla bie¿¹cego celu
        Renderer targetRenderer = target.GetComponent<Renderer>();
        if (targetRenderer != null)
        {
            targetRenderer.material = targetedMaterial;
        }
    }

    private void SetDefaultMaterial(Transform target)
    {
        Renderer renderer = currentTarget.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material = defaultMaterial;
            }
    }

    public bool IsTargetInRange(Transform target)
    {
        // Obliczamy odleg³oœæ do celu
        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        // Sprawdzamy, czy cel jest w zasiêgu widzenia
        return distanceToTarget <= shootingRange;
    }

    private void Shoot()
    {
        // Tworzymy nowy obiekt pocisku na pozycji naszej broni
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

        // Ustawiamy kierunek ruchu pocisku na kierunek naszej broni
        bullet.GetComponent<Rigidbody>().velocity = transform.forward * shootingForce;
    }
}
