using System;
using System.Collections.Generic;

namespace ToolsOfElesoftV2025.Models;

public partial class Twork
{
    public int Id { get; set; }

    public int? WorkType { get; set; }

    public DateTime? Date { get; set; }

    public string? InputText { get; set; }

    public string? OutputText { get; set; }
}
