using FluentNHibernate.Automapping;
using SurveyR.Core;

namespace SurveyR.Infrastructure.FluentNhibernate
{
    public class SurveyRMappingConfiguration : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(System.Type type)
        {
            return type != typeof(EntityBase) && typeof(EntityBase).IsAssignableFrom(type);
        }  
    }
}