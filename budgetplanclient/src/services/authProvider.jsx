import {createContext, useEffect, useState} from 'react';
import PropTypes from 'prop-types';
import userManager from './authConfig.jsx';

export const AuthContext = createContext(null);

export const AuthProvider = ({children}) => {
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

    useEffect(() => {
        const handleAccessTokenExpiring = () => {
            userManager.signinSilent().then((user) => {
                setUser(user);
            });
        };

        userManager.events.addAccessTokenExpiring(handleAccessTokenExpiring);

        return () => {
            userManager.events.removeAccessTokenExpiring(handleAccessTokenExpiring);
        };
    }, []);

    const login = () => {
        userManager.signinRedirect();
    };

    const logout = () => {
        userManager.signoutRedirect();
    };

    const authFetch = async (url, options = {}) => {
        const user = await userManager.getUser();

        if (!user || !user.access_token) {
            throw new Error("User is not authenticated");
        }

        const headers = {
            ...options.headers,
            Authorization: `Bearer ${user.access_token}`,
            'Content-Type': 'application/json'
        };

        const response = await fetch(url, {
            ...options,
            headers
        });

        if (!response.ok) {
            throw new Error('Network response was not ok');
        }

        // Read the raw response text
        const responseText = await response.text();

        // Log the raw response for debugging
        console.log(`Raw response from ${url}:`, responseText);

        // Attempt to parse the JSON, if applicable
        try {
            return responseText ? JSON.parse(responseText) : {};
        } catch (error) {
            console.error('Error parsing JSON:', error);
            throw new Error('Failed to parse JSON response');
        }
    };

    const fetchWithoutAuth = async (url, options = {}) => {
        const headers = {
            ...options.headers,
            'Content-Type': 'application/json'
        };

        const response = await fetch(url, {
            ...options,
            headers
        });

        if (!response.ok) {
            throw new Error('Network response was not ok');
        }

        return response.json();
    };


    return (
        <AuthContext.Provider value={{user, login, logout, authFetch, fetchWithoutAuth}}>
            {children}
        </AuthContext.Provider>
    );
};

AuthProvider.propTypes = {
    children: PropTypes.node.isRequired,
};