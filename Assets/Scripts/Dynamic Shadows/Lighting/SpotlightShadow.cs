using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightShadow : MonoBehaviour {

	public List<GameObject> shadowObjects;
	public List<debugRay> rays = new List<debugRay>();
	public float meldDist = 1.0f;
	public bool createColliders = false;
	public bool createMeld = false;
	public LayerMask mask;
	public GameObject shadowWall;

	public GameObject wallMeldPrefab;
	private List<Vector3> v;

	private GameObject pointHolder;

    private List<GameObject> createdColliders = new List<GameObject>();

	// Use this for initialization
	void Start () {
		v = new List<Vector3>();
	}
	
	// Update is called once per frame
	void Update () {
		if(createColliders) {
			collidersCreate();
			createColliders = false;
		}

		if(createMeld) {
			createMeldMesh();
			createMeld = false;
		}

		foreach (debugRay ray in rays) {
			Debug.DrawLine(ray.start, ray.dir, Color.green);
		}
	}

    Vector3 findCenter(List<ConvexHullPoint> points) {
        float maxX = points[0].location.x;
        float minX = points[0].location.x;
        float maxY = points[0].location.y;
        float minY = points[0].location.y;
        foreach (ConvexHullPoint point in points) {
            if (point.location.x > maxX)
                maxX = point.location.x;
            else if (point.location.x < minX)
                minX = point.location.x;

            if(point.location.y > maxY)
                maxY = point.location.y;
            else if (point.location.y < minY)
                minY = point.location.y;

        }

        float centerX = (maxX - minX) / 2.0f + minX;
        float centerY = (maxY - minY) / 2.0f + minY;

        return new Vector3(centerX, centerY);
    }

    Vector3 pointRelativeTo(Vector3 point, Vector3 center) {
        return point - center;
    }

	void collidersCreate() {
		foreach (GameObject obj in shadowObjects) {
            bool hitWall = true;
			print(obj.name);
			Mesh objMesh = obj.transform.GetChild(0).GetComponent<MeshFilter>().mesh;
			objMesh.UploadMeshData(false);
			HashSet<Vector3> vertices = new HashSet<Vector3>();
			v.Clear();
			objMesh.GetVertices(v);
			vertices.Clear();
			//rays.Clear();
			foreach( Vector3 vertex in v) {
				Vector3 trueVertex = obj.transform.localToWorldMatrix.MultiplyPoint3x4(vertex);
				vertices.Add(trueVertex);
			}
			List<ConvexHullPoint> points = new List<ConvexHullPoint>();
            int index = 0;
			foreach (Vector3 vertex in vertices) {
				Vector3 direction = vertex - transform.position;
				direction.Normalize();
				RaycastHit hit;
				if (Physics.Raycast(vertex, direction, out hit, Mathf.Infinity, mask)) {
					if (hit.collider.gameObject != shadowWall) {
						print (hit.collider.gameObject.name);
						print (shadowWall.name);
						print ("Not the right wall");
						hitWall = false;
						if (pointHolder != null) {
							cleanUp (pointHolder);
						}
						break;
					}
					pointHolder = hit.transform.parent.parent.GetChild(1).gameObject;
					//print(hit.transform.parent.parent.GetChild(1).gameObject.name);
					debugRay r;
					r.start = vertex;
					r.dir = hit.point;
					rays.Add(r);
					GameObject point = new GameObject();
                    point.name = "Point: " + index;
					point.transform.position = hit.point;
					point.transform.SetParent(pointHolder.transform);
                    ConvexHullPoint p;
                    p.location = point.transform.localPosition;
					p.complimentaryPoint = vertex;
                    p.arrayIndex = index;
					points.Add(p);
                    index++;
				}
                else {
                    print("No hit");
                    hitWall = false;
                    if (pointHolder != null) {
                        cleanUp(pointHolder);
                    }
                    break;
                }
			}

            if (!hitWall)
                continue;

            Vector3 center = findCenter(points);
            GameObject c = new GameObject();
            c.name = "Center";
            c.transform.SetParent(pointHolder.transform);
            c.transform.localPosition = center + new Vector3(0f, 0f, 0.5f);

			List<ConvexHullPoint> hull = createConvexHull(points);
			List<Vector3> convexHull = new List<Vector3>();

            List<ConvexHullPoint> hullP2 = new List<ConvexHullPoint>();
            int addition = 1;
			foreach(ConvexHullPoint hullPoint in hull) {
                GameObject hPointDouble = new GameObject();
                hPointDouble.name = "Point: " + (index + addition + 1);
                hPointDouble.transform.SetParent(pointHolder.transform);
                Vector3 doublePoint = hullPoint.location + new Vector3(0f, 0f, 1f);
                hPointDouble.transform.localPosition = doublePoint;
                ConvexHullPoint p;
                p.location = doublePoint;
				p.complimentaryPoint = new Vector3();
                p.arrayIndex = vertices.Count + addition;
                hullP2.Add(p);
                addition++;
			}

            foreach (ConvexHullPoint p in hullP2) {
                hull.Add(p);
            }

            foreach(ConvexHullPoint hullPoint in hull) {
                convexHull.Add(pointHolder.transform.GetChild(hullPoint.arrayIndex).transform.position - c.transform.position);
            }


            hull.Clear();

			int midVertices = convexHull.Count / 2;

			Mesh object3d = new Mesh();
			object3d.vertices = convexHull.ToArray();

            List<int> trianglePoints = new List<int>();

			// Fan triangles
			for(int a = 1; a < (convexHull.Count / 2) - 1; a++) {
				trianglePoints.Add(0);
				trianglePoints.Add(a);
				trianglePoints.Add(a + 1);

				trianglePoints.Add(midVertices);
				trianglePoints.Add(a + midVertices);
				trianglePoints.Add(a + midVertices + 1);
			}


			//Intermediate triangles
			int i;
			for(i = 0; i < (convexHull.Count / 2) - 1; i++) {
				trianglePoints.Add(i);
				trianglePoints.Add(i + 1);
				trianglePoints.Add(i + midVertices + 1);

				trianglePoints.Add(i);
				trianglePoints.Add(i + midVertices);
				trianglePoints.Add(i + midVertices + 1);
			}
			i++;
			trianglePoints.Add(i);
			trianglePoints.Add(0);
			trianglePoints.Add(convexHull.Count - 1);

			trianglePoints.Add(i);
			trianglePoints.Add(i + 1);
			trianglePoints.Add(convexHull.Count - 1);


			object3d.triangles = trianglePoints.ToArray();

            

            GameObject mesh = new GameObject();
			mesh.name = obj.name;
			mesh.AddComponent<MeshFilter>().mesh = object3d;
            mesh.AddComponent<MeshCollider>().convex = true;
           
            mesh.transform.position = c.transform.position;

            LightSourceControl lightCont = GetComponent<LightSourceControl>();
            Vector3 pos = mesh.transform.position;
            switch (lightCont.m_CurrentFacingDirection) {
                case LightSourceControl.FacingDirection.North:
                    pos.z = GameObject.Find("North_Floor").transform.position.z;
                    mesh.transform.position = pos;
                    break;
                case LightSourceControl.FacingDirection.South:
                    pos.z = GameObject.Find("South_Floor").transform.position.z;
                    mesh.transform.position = pos;
                    break;
                case LightSourceControl.FacingDirection.West:
                    pos.x = GameObject.Find("West_Floor").transform.position.x;
                    mesh.transform.position = pos;
                    break;
                case LightSourceControl.FacingDirection.East:
                    pos.x = GameObject.Find("East_Floor").transform.position.x;
                    mesh.transform.position = pos;
                    break;
            }

            cleanUp(pointHolder);

            createdColliders.Add(mesh);
		}
	}

    void cleanUp(GameObject pointHolder) {
        while (pointHolder.transform.childCount > 0) {
            Transform pointObj = pointHolder.transform.GetChild(0);
            pointObj.SetParent(null);
            GameObject.Destroy(pointObj.gameObject);
        }
        pointHolder = null;
    }

	const int TURN_LEFT = 1;
	const int TURN_RIGHT = -1;
	const int TURN_NONE = 0;
	public int turn(Vector3 p, Vector3 q, Vector3 r)
	{
		return ((q.x - p.x) * (r.y - p.y) - (r.x - p.x) * (q.y - p.y)).CompareTo(0);
	}

	public void keepLeft(List<ConvexHullPoint> hull, ConvexHullPoint r)
	{
		while (hull.Count > 1 && turn(hull[hull.Count - 2].location, hull[hull.Count - 1].location, r.location) != TURN_LEFT)
		{
			hull.RemoveAt(hull.Count - 1);
		}
		if (hull.Count == 0 || hull[hull.Count - 1].location != r.location)
		{
			hull.Add(r);
		}

	}

	public double getAngle(Vector3 p1, Vector3 p2)
	{
		float xDiff = p2.x - p1.x;
		float yDiff = p2.y - p1.y;
		return Mathf.Atan2(yDiff, xDiff) * 180.0 / Mathf.PI;
	}

	public List<ConvexHullPoint> MergeSort(ConvexHullPoint p0, List<ConvexHullPoint> arrPoint)
	{
		if (arrPoint.Count == 1)
		{
			return arrPoint;
		}
		List<ConvexHullPoint> arrSortedInt = new List<ConvexHullPoint>();
		int middle = (int)arrPoint.Count / 2;
		List<ConvexHullPoint> leftArray = arrPoint.GetRange(0, middle);
		List<ConvexHullPoint> rightArray = arrPoint.GetRange(middle, arrPoint.Count - middle);
		leftArray = MergeSort(p0, leftArray);
		rightArray = MergeSort(p0, rightArray);
		int leftptr = 0;
		int rightptr = 0;
		for (int i = 0; i < leftArray.Count + rightArray.Count; i++)
		{
			if (leftptr == leftArray.Count)
			{
				arrSortedInt.Add(rightArray[rightptr]);
				rightptr++;
			}
			else if (rightptr == rightArray.Count)
			{
				arrSortedInt.Add(leftArray[leftptr]);
				leftptr++;
			}
			else if (getAngle(p0.location, leftArray[leftptr].location) < getAngle(p0.location, rightArray[rightptr].location))
			{
				arrSortedInt.Add(leftArray[leftptr]);
				leftptr++;
			}
			else
			{
				arrSortedInt.Add(rightArray[rightptr]);
				rightptr++;
			}
		}
		return arrSortedInt;
	}

	public List<ConvexHullPoint> createConvexHull(List<ConvexHullPoint> points)
	{

		ConvexHullPoint p0 = points[0];
		foreach (ConvexHullPoint value in points)
		{
			
			if (p0.location.y > value.location.y)
				p0 = value;
			
		}
		List<ConvexHullPoint> order = new List<ConvexHullPoint>();
		foreach (ConvexHullPoint value in points)
		{
			if (p0 != value)
				order.Add(value);
		}

		order = MergeSort(p0, order);
		List<ConvexHullPoint> result = new List<ConvexHullPoint>();
		result.Add(p0);
		result.Add(order[0]);
		result.Add(order[1]);
		order.RemoveAt(0);
		order.RemoveAt(0);

		foreach (ConvexHullPoint value in order)
		{
			keepLeft(result, value);
		}

		return result;
	}

	void createMeldMesh() {
		foreach (GameObject obj in shadowObjects) {
			Vector3 pos = obj.transform.position + (meldDist * (obj.transform.position - transform.position).normalized);
			GameObject w = Instantiate(wallMeldPrefab);
			w.transform.position = pos;
			w.transform.LookAt(transform);

			Mesh objMesh;
			if (obj.transform.Find (obj.name + "_Mesh_Master") == null) {
				objMesh = obj.transform.GetChild (0).GetComponentInChildren<MeshFilter> ().mesh;
			}
			else { 
				objMesh = obj.transform.Find(obj.name + "_Mesh_Master").GetChild(0).GetComponentInChildren<MeshFilter>().mesh;
			}
			HashSet<Vector3> vertices = new HashSet<Vector3>();
			v.Clear();
			objMesh.GetVertices(v);
			vertices.Clear();
			rays.Clear();
			foreach( Vector3 vertex in v) {
				Vector3 trueVertex = obj.transform.localToWorldMatrix.MultiplyPoint3x4(vertex);
				vertices.Add(trueVertex);
			}
			List<ConvexHullPoint> points = new List<ConvexHullPoint>();
			int index = 0;
			foreach (Vector3 vertex in vertices) {
				Vector3 direction = vertex - transform.position;
				direction.Normalize();
				RaycastHit hit;
				if (Physics.Raycast(vertex, direction, out hit, Mathf.Infinity, mask)) {
					pointHolder = hit.transform.parent.parent.GetChild(1).gameObject;
					debugRay r;
					print(vertex);
					r.start = vertex;
					r.dir = hit.point;
					rays.Add(r);
					GameObject point = new GameObject();
					point.name = "Point: " + index;
					point.transform.position = hit.point;
					point.transform.SetParent(pointHolder.transform);
					ConvexHullPoint p;
					p.location = point.transform.localPosition;
					p.complimentaryPoint = vertex;
					p.arrayIndex = index;
					points.Add(p);
					index++;
				}
			}

			Vector3 center = findCenter(points);
			GameObject c = new GameObject();
			c.name = "Center";
			c.transform.SetParent(pointHolder.transform);
			c.transform.localPosition = center;

			List<ConvexHullPoint> hull = createConvexHull(points);


			List<Vector3> convexHull = new List<Vector3>();
			foreach(ConvexHullPoint hullPoint in hull) {
				convexHull.Add(pointHolder.transform.GetChild(hullPoint.arrayIndex).transform.position - c.transform.position);
			}

			foreach(ConvexHullPoint hullPoint in hull) {
				convexHull.Add(hullPoint.complimentaryPoint - c.transform.position);
			}

			hull.Clear();
			int midVertices = convexHull.Count / 2;
			Mesh object3d = new Mesh();
			object3d.vertices = convexHull.ToArray();

			List<int> trianglePoints = new List<int>();

			// Fan triangles
			for(int a = 1; a < (convexHull.Count / 2) - 1; a++) {
				trianglePoints.Add(a + 1);
				trianglePoints.Add(a);
				trianglePoints.Add(0);

//				trianglePoints.Add(6);
//				trianglePoints.Add(a + 6);
//				trianglePoints.Add(a + 7);
			}


			//Intermediate triangles
			int i;
			for(i = 0; i < (convexHull.Count / 2) - 1; i++) {
				trianglePoints.Add(i);
				trianglePoints.Add(i + 1);
				trianglePoints.Add(i + midVertices + 1);

				trianglePoints.Add(i + midVertices + 1);
				trianglePoints.Add(i + midVertices);
				trianglePoints.Add(i);

			}
			i++;
			trianglePoints.Add(convexHull.Count - 1);
			trianglePoints.Add(0);
			trianglePoints.Add(i);

			trianglePoints.Add(i);
			trianglePoints.Add(i + 1);
			trianglePoints.Add(convexHull.Count - 1);



			object3d.triangles = trianglePoints.ToArray();

			GameObject mesh = new GameObject();
			mesh.AddComponent<MeshFilter>().mesh = object3d;
			mesh.AddComponent<MeshCollider>().convex = true;

//			mesh.GetComponent<MeshFilter>().mesh.RecalculateNormals();

			mesh.AddComponent<MeshRenderer>();
			mesh.layer = LayerMask.NameToLayer("Ignore Shadowmeld Collision");

			mesh.transform.position = c.transform.position;

			GameObject.Destroy(w);

            createdColliders.Add(mesh);

			StartCoroutine(flipNormals(mesh));
		}
	}

    public void destroyColliders() {
        foreach(GameObject collider in createdColliders) {
            GameObject.Destroy(collider);
        }
    }

	IEnumerator flipNormals(GameObject obj) {
		while(obj.GetComponent<MeshFilter>().mesh.normals.Length == 0) {
			obj.GetComponent<MeshFilter>().mesh.RecalculateNormals();
			yield return null;
		}
		obj.GetComponent<MeshFilter>().mesh.RecalculateNormals();
		int n = 0;
		List<Vector3> newNormals = new List<Vector3>();
		foreach(Vector3 norm in obj.GetComponent<MeshFilter>().mesh.normals) {

			if (n % 2 == 0) {
				newNormals.Add(-norm);
			} else {
				newNormals.Add(norm);
			}
			n++;
		}

		obj.GetComponent<MeshFilter>().mesh.normals = newNormals.ToArray();	
		yield return null;
	}

}
