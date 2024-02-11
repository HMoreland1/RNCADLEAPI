using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RNCADLEAPI.Data;

public partial class ContentCategory
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<LearningContent> LearningContents { get; set; } = new List<LearningContent>();
   
}
