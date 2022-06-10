using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NesaBotDesktop.Models {
  public class MarkModel {
    public string? Id { get; set; }
    public string? Course { get; set; }
    public char? CourseType { get; set; }
    public string? Subject { get; set; }
    public string? SubjectToken { get; set; }
    public string? Title { get; set; }
    public DateTime? Date { get; set; }
    public double? Mark { get; set; }
    public double? Weight { get; set; }
    public bool? IsConfirmed { get; set; }
  }
}
