using WinformGeneralDeveloperFrame.Commons;

namespace MES.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("lottery")]
    public partial class lotteryInfo
    {
    ///id
    [ModelBindControl("txtid")]
    public int id{set;get;}
    ///red1
    [ModelBindControl("txtred1")]
    public int red1{set;get;}
    ///red2
    [ModelBindControl("txtred2")]
    public int red2{set;get;}
    ///red3
    [ModelBindControl("txtred3")]
    public int red3{set;get;}
    ///red4
    [ModelBindControl("txtred4")]
    public int red4{set;get;}
    ///red5
    [ModelBindControl("txtred5")]
    public int red5{set;get;}
    ///red6
    [ModelBindControl("txtred6")]
    public int red6{set;get;}
    ///blue
    [ModelBindControl("txtblue")]
    public int blue{set;get;}
    
    }
}