namespace Software2KnowledgeCheck1
{
    //make construction generic with T variable for various buildings
    internal class Construction<T> where T : Building
    {
        public void CreateBuilding<T>(T building, City city) where T : Building
        {
            // Get materials
            var materialRepo = new MaterialsRepo();
            var materialsNeeded = materialRepo.GetMaterials();

            var permitRepo = new ZoningAndPermitRepo();

            //Rework method call to allow for any building
            var buildingWasMade = ConstructBuilding(materialsNeeded, permitRepo.GetPermit(), permitRepo.ZoningApproves());

            if (buildingWasMade)
            {
                city.Buildings.Add(building);
            }
        }

        //Rewrite ConstructBuilding bool check since it's now defined what type in the CreateBuilding method
        public bool ConstructBuilding(List<string> materials, bool permit, bool zoning)
        {
            if (permit && zoning)
            {
                foreach (var material in materials)
                {
                    if (material == "concrete")
                    {
                        // start laying foundation
                    }
                    else if (material == "Steel")
                    {
                        // Start building structure
                    }
                    // etc etc...

                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}