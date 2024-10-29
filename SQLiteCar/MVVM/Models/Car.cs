using System;
using SQLite;

namespace SQLiteCar.MVVM.Models;

public class Car
{
    [PrimaryKey, AutoIncrement]
    public int ID { get; set; }

    [Column("Model")]
    public string Model { get; set; }

    [Column("Color")]
    public string Color { get; set; }
}