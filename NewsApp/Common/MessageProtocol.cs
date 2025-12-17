
namespace NewsApp.Common
{
    public static class MessageProtocol
    {
        public static class RequestCommand
        {
            public const string LOGIN = "LOGIN";
            public const string REGISTER = "REGISTER";
            public const string GET_LIST_ARTICLES = "GET_LIST_ARTICLES";

            public const string GET_ARTICLE_DETAIL = "GET_ARTICLE_DETAIL";

            public const string GET_PROFILE = "GET_PROFILE";
            public const string UPDATE_PROFILE = "UPDATE_PROFILE";

            public const string POST_ARTICLE = "POST_ARTICLE";

            public const string POST_COMMENT = "POST_COMMENT";
            public const string LOGOUT = "LOGOUT";
            public const string GET_CATEGORIES = "GET_CATEGORIES";
            public const string GET_LATEST_ARTICLES = "GET_LATEST_ARTICLES";
            public const string GET_ARTICLES_BY_CATEGORY = "GET_ARTICLES_BY_CATEGORY";
            public const string SEARCH_ARTICLES = "SEARCH_ARTICLES";
            public const string GET_COMMENTS = "GET_COMMENTS";

            // Admin Commands
            public const string GET_ALL_USERS = "GET_ALL_USERS";
            public const string DELETE_USER = "DELETE_USER";
            public const string DELETE_ARTICLE = "DELETE_ARTICLE";
            public const string ADD_CATEGORY = "ADD_CATEGORY";
            public const string UPDATE_CATEGORY = "UPDATE_CATEGORY";
            public const string DELETE_CATEGORY = "DELETE_CATEGORY";
        }
    }
}