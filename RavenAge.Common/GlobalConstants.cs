namespace RavenAge.Common
{
    public static class GlobalConstants
    {
        public const string SystemName = "RavenAge";

        public const string AdministratorRoleName = "Administrator";

        ////Base Attacks, Defence, Healt

        public const int ElfArcherBaseAttack = 1000;
        public const int ElfArcherBaseDefence = 1000;
        public const int ElfArcherBaseHealt = 1000;

        public const int HumanArcherBaseAttack = 1000;
        public const int HumanArcherBaseDefence = 1000;
        public const int HumanArcherBaseHealt = 1000;

        public const int UndeadArcherBaseAttack = 1000;
        public const int UndeadArcherBaseDefence = 1000;
        public const int UndeadArcherBaseHealt = 1000;


        //var curentSilver = city.Silver;
        //var curentWood = city.Wood;

        //var silverNeeded = (input.ArcharQuantity * 50) + (input.InfantryQuantity * 100)
        //    + (input.CavalryQuantity * 100) + (input.ArtilleryQuantity * 25);

        //var woodNeeded = (input.ArcharQuantity * 50) + (input.InfantryQuantity * 15)
        //    + (input.CavalryQuantity * 15) + (input.ArtilleryQuantity * 100);

        public const int ArcherSilverCost = 50;
        public const int InfantrySilverCost = 100;
        public const int CavalrySilverCost = 150;
        public const int ArtillerySilverCost = 25;

        public const int ArcherWoodCost = 50;
        public const int InfantryWoodCost = 15;
        public const int CavalryWoodCost = 15;
        public const int ArtilleryWoodCost = 100;

    }
}
