import { createContext, useEffect, useState } from 'react';
import PropTypes from 'prop-types';
import userManager from './AuthConfig.jsx';

export const AuthContext = createContext(null);

export const AuthProvider = ({ children }) => {
    const [user, setUser] = useState(null);

    useEffect(() => {
        userManager.getUser().then((loadedUser) => {
            if (loadedUser) {
                setUser(loadedUser);
            }
        });

        const onUserLoaded = (loadedUser) => {
            setUser(loadedUser);
        };

        userManager.events.addUserLoaded(onUserLoaded);

        return () => {
            userManager.events.removeUserLoaded(onUserLoaded);
        };
    }, []);

    const login = () => {
        userManager.signinRedirect();
    };

    const logout = () => {
        userManager.signoutRedirect();
    };

    return (
        <AuthContext.Provider value={{ user, login, logout }}>
            {children}
        </AuthContext.Provider>
    );
};

AuthProvider.propTypes = {
    children: PropTypes.node.isRequired,
};