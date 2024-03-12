using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Medium.Application.Mappers
{
    public static class MyMapper
    {
        public static TEntity MyMapp<TEntity>(this object entity)
            where TEntity : class
        {
            var newEntity = Activator.CreateInstance<TEntity>();
            var typeNewEntity = newEntity.GetType();
            var typeObject = entity.GetType();

            PropertyInfo[] properties = typeNewEntity.GetProperties();

            foreach (var property in properties)
            {
                var objectProperty = typeObject.GetProperty(property.Name);

                if (objectProperty != null)
                    property.SetValue(newEntity, objectProperty.GetValue(entity));
            }

            return (TEntity)newEntity;
        }
    }
}
