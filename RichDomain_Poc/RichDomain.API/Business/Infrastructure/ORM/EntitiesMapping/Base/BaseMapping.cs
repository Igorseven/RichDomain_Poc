﻿namespace RichDomain.API.Business.Insfrastructure.ORM.EntitiesMapping.Base;
public abstract class BaseMapping
{
    private const string SchemaDefault = "RichDomain";
    protected string Schema { get; set; }

    public BaseMapping() =>
        Schema = SchemaDefault;

    public BaseMapping(string schema) =>
        Schema = schema;
}
