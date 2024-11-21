using System;
using System.Collections.Generic;

namespace crudapi.Models;

public partial class EmpTable
{
    public int Eid { get; set; }

    public string Ename { get; set; } = null!;

    public int Eage { get; set; }

    public DateOnly Edoj { get; set; }

    public string Estatus { get; set; } = null!;
}
