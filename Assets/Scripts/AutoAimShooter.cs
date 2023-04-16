using UnityEngine;

public class AutoAimShooter : MonoBehaviour
{
    public LayerMask targetMask; // warstwa obiekt�w, kt�re chcemy atakowa�
    public float fireRate = 1f; // cz�stotliwo�� strzelania
    public float shootingRange = 10f; // zasi�g widzenia
    public float shootingForce; 
    public GameObject bulletPrefab; // prefabrykat pocisku

    public Material targetedMaterial; // materia� dla celu, kt�ry jest aktualnie namierzany
    public Material defaultMaterial;
    private Transform currentTarget;

    private float nextFireTime; // czas nast�pnego strza�u

    public Camera cam;

    private void Update()
    {
        // Pobieramy wszystkie obiekty z warstwy cel�w, kt�re s� w zasi�gu widzenia
        Collider[] targets = Physics.OverlapSphere(transform.position, shootingRange, targetMask);

        // Je�li nie ma �adnych cel�w, to nie robimy nic
        if (targets == null || targets.Length == 0)
        {
            return;
        }

        Transform newTarget = targets[Random.Range(0, targets.Length)].transform;

        // Je�li nowy cel jest r�ny od bie��cego, to przywracamy domy�lny materia� dla bie��cego celu
        if (newTarget != currentTarget && currentTarget != null)
        {
            SetDefaultMaterial(currentTarget);
        }

        // Ustawiamy nowy cel jako bie��cy cel
        currentTarget = newTarget;

        // Sprawdzamy, czy bie��cy cel jest w zasi�gu widzenia i czas strzelania zosta� osi�gni�ty
        if (IsTargetInRange(currentTarget) && Time.time >= nextFireTime )
        {

            SetTargetedMaterial(currentTarget);


            if (Input.GetKeyDown(KeyCode.Z))
            {
                // Obracamy si� w kierunku bie��cego celu
                transform.LookAt(currentTarget);

                // Strzelamy
                Shoot();

                // Ustawiamy czas nast�pnego strza�u
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
        // Przywracamy domy�lny materia� dla poprzedniego celu
        if (currentTarget != null && currentTarget != target)
        {
            Renderer renderer = currentTarget.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material = defaultMaterial;
            }
        }

        // Zmieniamy materia� dla bie��cego celu
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
        // Obliczamy odleg�o�� do celu
        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        // Sprawdzamy, czy cel jest w zasi�gu widzenia
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
