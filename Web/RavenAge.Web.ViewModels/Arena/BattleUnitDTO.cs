namespace RavenAge.Web.ViewModels.Arena
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using AutoMapper;
    using RavenAge.Common;
    using RavenAge.Data.Models.Models;
    using RavenAge.Services.Mapping;

    public class BattleUnitDTO : IMapFrom<Unit> /* IMapFrom<Archers>, IMapFrom<Infantry>, IMapFrom<Artillery>, IMapFrom<Cavalry>,*/ /*IHaveCustomMappings*/
    {
        public BattleUnitDTO()
        {
            this.AttackPriority = new List<UnitType>();
        }

        public UnitType Type { get; set; }

        public List<UnitType> AttackPriority { get; set; }

        public int Count { get; set; }

        public int Attack { get; set; }

        public int Bonus { get; set; }

        public int Defence { get; set; }

        public int DefenceBonus { get; set; }

        public int Health { get; set; }


        public int HealthBonus { get; set; }

        public bool AttackRune { get; set; }

        public bool DefenseRune { get; set; }

        public bool HealthRune { get; set; }

        public int SingleUnitAttack => this.Attack + this.Bonus;

        public int SingleUnitHealth => this.Health + this.HealthBonus + this.Defence + this.DefenceBonus;

        public int SingleUnitDefence { get; set; }

        public int TotalUnitHealth => this.SingleUnitHealth * this.Count;

        public int TotalUnitAttack => this.SingleUnitAttack * this.Count;

        public bool HasAttacked { get; set; }

        //public void CreateMappings(IProfileExpression configuration)
        //{
        //    //this.Type = UnitType.Archers;

        //    configuration.CreateMap<Unit, BattleArchersDTO>()
        //                    .ForMember(t => t.SingleUnitAttack, opt => opt.MapFrom(s => s.Attack + s.Bonus))
        //                    .ForMember(t => t.SingleUnitAttack, opt => opt.MapFrom(s => s.Health + s.HealthBonus + s.Defence + s.DefenceBonus));
        //}
    }
}
