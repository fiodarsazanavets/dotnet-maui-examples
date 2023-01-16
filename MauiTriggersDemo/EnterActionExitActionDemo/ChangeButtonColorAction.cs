using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterActionExitActionDemo;

public class ChangeButtonColorAction : TriggerAction<Button>
{
    protected override void Invoke(Button sender)
    {
        sender.BackgroundColor = Colors.Red;
    }
}
