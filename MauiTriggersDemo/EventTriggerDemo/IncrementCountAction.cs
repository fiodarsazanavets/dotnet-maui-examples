using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTriggerDemo;

public class IncrementCountAction : TriggerAction<Button>
{
    protected override void Invoke(Button sender)
    {
        if (!sender.Text.Contains("time"))
        {
            sender.Text = $"Clicked 1 time";
        }
        else
        {
            var count = int.Parse(sender.Text.Split(' ')[1]);
            sender.Text = $"Clicked {++count} times";
        }
    }
}
