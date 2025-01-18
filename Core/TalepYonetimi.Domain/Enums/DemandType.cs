using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalepYonetimi.Domain.Enums
{
    public enum DemandType
    {
        Demo, // demo talebi
        Purchase, // satınalma talebi
        Training, // eğitim desteği talebi
        Customization, // özelleştirme talebi
        ErrorSolution, // hata çözüm talebi
        PurchaseCancellation // satınalma iptali talebi

    }
}
