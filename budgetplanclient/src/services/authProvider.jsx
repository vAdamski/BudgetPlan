import { createContext, useEffect, useState } from 'react';
import PropTypes from 'prop-types';
import userManager from './authConfig.jsx';

export const AuthContext = createContext(null);

export const AuthProvider = ({ children }) => {
    const [user, setUser] = useState(() => {
        const storedUser = localStorage.getItem('user');
        return storedUser ? JSON.parse(storedUser) : null;
    });

    useEffect(() => {
        const checkUserToken = async () => {
            try {
                let currentUser = await userManager.getUser();

                if (currentUser && currentUser.expired) {
                    currentUser = await userManager.signinSilent();
                    setUser(currentUser);
                } else if (currentUser) {
                    setUser(currentUser);
                } else {
                    console.log('User is not logged in');
                }

                if (currentUser) {
                    localStorage.setItem('user', JSON.stringify(currentUser));
                }
            } catch (error) {
                console.error('Failed to renew token', error);
                userManager.signinRedirect();
            }
        };

        checkUserToken();
    }, []);

    useEffect(() => {
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
        try {
            let currentUser = await userManager.getUser();

            if (!currentUser || !currentUser.access_token) {
                throw new Error("User is not authenticated");
            }

            const headers = {
                ...options.headers,
                Authorization: `Bearer ${currentUser.access_token}`,
                'Content-Type': 'application/json'
            };

            const response = await fetch(url, {
                ...options,
                headers
            });

            if (response.status === 401) { // If unauthorized, try to renew the token
                currentUser = await userManager.signinSilent(); // Renew the token
                setUser(currentUser); // Update the user state

                const retryHeaders = {
                    ...options.headers,
                    Authorization: `Bearer ${currentUser.access_token}`,
                    'Content-Type': 'application/json'
                };

                const retryResponse = await fetch(url, {
                    ...options,
                    headers: retryHeaders
                });

                if (!retryResponse.ok) {
                    throw new Error('Network response was not ok after retry');
                }

                return handleResponse(retryResponse);
            }

            if (!response.ok) {
                throw new Error('Network response was not ok');
            }

            return handleResponse(response);
        } catch (error) {
            throw new Error(`authFetch failed: ${error.message}`);
        }
    };

    const handleResponse = async (response) => {
        const contentType = response.headers.get("content-type");
        if (contentType && contentType.includes("application/json")) {
            return response.json();
        } else {
            return response;
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
        <AuthContext.Provider value={{ user, login, logout, authFetch, fetchWithoutAuth }}>
            {children}
        </AuthContext.Provider>
    );
};

AuthProvider.propTypes = {
    children: PropTypes.node.isRequired,
};