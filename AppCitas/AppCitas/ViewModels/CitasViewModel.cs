namespace AppCitas.ViewModels
{
    using AppCitas.Services;
    public class CitasViewModel : BaseViewModel
    {
        #region Services
        private ApiService apiService;
        #endregion

        #region Attributes      
        private bool isRefreshing;
        private string filter;
        #endregion
    }
}
