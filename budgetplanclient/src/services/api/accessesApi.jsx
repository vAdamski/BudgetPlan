import {useContext} from 'react';
import {API_URL} from './apiConfig.jsx';
import {AuthContext} from "../authProvider.jsx";

const useAccessesApi = () => {
    const {authFetch} = useContext(AuthContext);

    const addUserToAccess = async (accessId, userEmail) => {
        return await authFetch(`${API_URL}/api/accesses/${accessId}/users`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                userEmail: userEmail
            })
        });
    }

    const removeUserFromAccess = async (accessId, userEmail) => {
        return await authFetch(`${API_URL}/api/accesses/${accessId}/users`, {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                userEmail: userEmail
            })
        });
    }

    return {
        addUserToAccess,
        removeUserFromAccess
    }
}

export default useAccessesApi;