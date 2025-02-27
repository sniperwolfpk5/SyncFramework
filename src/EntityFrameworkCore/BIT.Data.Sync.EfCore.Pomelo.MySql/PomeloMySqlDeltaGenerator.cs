﻿
using BIT.EfCore.Sync;
//using Microsoft.EntityFrameworkCore.Sqlite.Storage.Internal;
//using Microsoft.EntityFrameworkCore.Sqlite.Update.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Update;
using Pomelo.EntityFrameworkCore.MySql.Internal;
using Pomelo.EntityFrameworkCore.MySql.Storage.Internal;
using Pomelo.EntityFrameworkCore.MySql.Update.Internal;
using System;
namespace BIT.Data.Sync.EfCore.Sqlite
{
    public class PomeloMySqlDeltaGenerator : DeltaGeneratorBase
    {

        public PomeloMySqlDeltaGenerator()
        {

        }

        public override IUpdateSqlGenerator CreateInstance(IServiceProvider serviceProvider)
        {
            TypeMappingSourceDependencies TypeMappingSourceDependencies = serviceProvider.GetService(typeof(TypeMappingSourceDependencies)) as TypeMappingSourceDependencies;
            RelationalTypeMappingSourceDependencies RelationalTypeMappingSourceDependencies = serviceProvider.GetService(typeof(RelationalTypeMappingSourceDependencies)) as RelationalTypeMappingSourceDependencies;

            var options = new MySqlOptions();
            var mySqlUpdateSqlGenerator = new MySqlUpdateSqlGenerator(
                            new UpdateSqlGeneratorDependencies(
                                new MySqlSqlGenerationHelper(
                                    new RelationalSqlGenerationHelperDependencies(),
                                    options),
                                new MySqlTypeMappingSource(
                                   TypeMappingSourceDependencies,
                                   RelationalTypeMappingSourceDependencies,
                                    options)));



            return mySqlUpdateSqlGenerator ;
        }
    }
}
