///<Summary>
/// Here's how the algorithm works:
/// It takes an array of Vector3s and a float value representing the distance squared within which two points are considered to be close to each other.
/// It initializes an empty 2D array to store the indices of the points that are close to each other. The first dimension of the array corresponds to the index of each point in the input array, and the second dimension stores the indices of the points that are within the specified distance of the point.
/// It initializes a temporary 1D array to store the indices of the points that are close to the current point being processed.
/// It loops through each point in the input array, and for each point, it loops through all the other points in the array.
/// If the current point and the other point being processed are not the same, and the distance between them (squared) is less than or equal to the specified distance squared, the index of the other point is added to the temporary array.
/// After processing all the points, the number of indices in the temporary array is used to initialize a new 1D array in the result array for the current point.
/// Finally, the indices in the temporary array are copied to the new 1D array in the result array for the current point.
///</Summary>
///<Returns>The algorithm returns the 2D result array, which contains the indices of the points that are within the specified distance of each point in the input array.</Returns>
public static void DetectInternalCollisions(Vector3[] points, float distanceSquared, out int[][] collidedParticles, out int[] collisionCounts){
  for (int i = 0; i < points.Length; i++){
    int collidedParticleIndex = 0;
    for (int j = 0; j < points.Length; j++) {
      if(i==j) {continue;}
      if((points[i]-points[j]).sqrMagnitude <= distanceSquared){result[i][collidedParticleIndex++] = j;}
    }
    collisionCounts[i] = collidedParticleIndex;
  }
}
