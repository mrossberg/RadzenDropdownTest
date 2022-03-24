using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace RadenDropdownTest.Ui.Pages
{
    public partial class DropdownTest : ComponentBase
    {

        public System.Timers.Timer PeriodicalComponentRemover { get; set; }
        public int SecondsToRemoval { get; set; } = 5;
        public int CurrentComponentCount { get; set; }

        protected override Task OnInitializedAsync()
        {
            PeriodicalComponentRemover = new System.Timers.Timer(1000);

            PeriodicalComponentRemover.Start();
            PeriodicalComponentRemover.Elapsed += PeriodicalComponentRemover_Elapsed;
            return base.OnInitializedAsync();
        }

        private void PeriodicalComponentRemover_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            InvokeAsync(() =>
            {
                if (SecondsToRemoval > 0)
                {
                    --SecondsToRemoval;
                    StateHasChanged();
                }
                if (SecondsToRemoval <= 0)
                {
                    SecondsToRemoval = 5;
                    RemoveComponent();
                }
            });
        }

        private void RemoveComponent()
        {
            if (CurrentComponentCount > 0)
                CurrentComponentCount--;
        }

        private void AddComponent()
        {
            CurrentComponentCount++;
            StateHasChanged();
        }
    }
}
