using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CatalogoProdutos.Client.Components
{
    public abstract partial class Crud<T, TDialog> where TDialog : ComponentBase
    {
        [Parameter]
        public string ApiResource { get; set; }
        [Parameter]
        public RenderFragment ItemIndividual { get; set; }
        [Parameter]
        public RenderFragment ItemAdicionar { get; set; }
        [Parameter]
        public T Model { get; set; }

        // Carrega
        async Task LoadItems()
        {
            try
            {
                items = await http.GetFromJsonAsync<List<T>>($"api/{ApiResource}");
            }
            catch (Exception)
            {
                Snackbar.Add("Ocorreu um erro ao tentar recuperar os items", Severity.Error);
            }
        }

        async Task OnValidSubmit()
        {
            try
            {
                await http.PostAsJsonAsync<T>($"api/{ApiResource}", Model);
                await LoadItems();
                Snackbar.Add("Item adicionado", Severity.Success);
            }
            catch (Exception)
            {
                Snackbar.Add("Ocorreu um erro ao tentar adicionar o item", Severity.Error);
            }
        }

        // Lista
        List<T> items;

        protected override async Task OnInitializedAsync()
        {
            await LoadItems();
        }

        // Delete
        async Task Delete(int id)
        {
            try
            {
                await http.DeleteAsync($"api/{ApiResource}/{id}");
                await LoadItems();
            }
            catch (Exception)
            {
                Snackbar.Add("Ocorreu um erro ao tentar deletar uma item", Severity.Error);
            }
        }

        // Editar
        DialogOptions maxWidth = new DialogOptions() { MaxWidth = MaxWidth.Medium, FullWidth = true };
        async Task Editar(T item)
        {
            try
            {
                var parameters = new DialogParameters { ["item"] = item };

                var dialog = DialogService.Show<TDialog>("Editar item", parameters, maxWidth);
                var result = await dialog.Result;

                if (!result.Cancelled)
                {
                    await LoadItems();
                }
            }
            catch (Exception)
            {
                Snackbar.Add("Ocorreu um erro ao tentar editar uma item", Severity.Error);
            }
        }
    }
}
