import { UserManager, WebStorageStateStore } from 'oidc-client';

const config = {
    authority: "https://localhost:5001",
    client_id: "react",
    redirect_uri: "http://localhost:5173/authentication/login-callback",
    post_logout_redirect_uri: "http://localhost:5173/",
    response_type: "code",
    scope: "openid profile api1",
    loadUserInfo: true,
    automaticSilentRenew: true,
    filterProtocolClaims: true,
    userStore: new WebStorageStateStore({ store: window.localStorage })
};

const userManager = new UserManager(config);

export default userManager;