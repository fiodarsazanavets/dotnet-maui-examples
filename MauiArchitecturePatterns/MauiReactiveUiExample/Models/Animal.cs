using MongoDB.Bson;
using Realms;

namespace MauiReactiveUiExample.Models;

public class Animal : RealmObject
{
    [PrimaryKey]
    public ObjectId Id { get; set; } = ObjectId.GenerateNewId();
    public string Name { get; set; }
}
