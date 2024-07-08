import {useContext} from "react";
import {AuthContext} from "../authProvider.jsx";
import {API_URL} from "./apiConfig.jsx";

const useTransactionDetailsApi = () => {
    const {authFetch} = useContext(AuthContext);

    const createTransactionDetails = async (dto) => {
        return await authFetch(`${API_URL}/api/transactionDetails`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'Accept': 'application/json',
            },
            body: JSON.stringify(dto),
        });
    }

    const putTransactionDetails = async (id, dto) => {
        return await authFetch(`${API_URL}/api/transactionDetails/${id}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
                'Accept': 'application/json',
            },
            body: JSON.stringify(dto),
        });
    }

    const deleteTransactionDetails = async (id) => {
        return await authFetch(`${API_URL}/api/transactionDetails/${id}`, {
            method: 'DELETE',
        });
    }

    return ({
        createTransactionDetails,
        putTransactionDetails,
        deleteTransactionDetails,
    });
}

export default useTransactionDetailsApi;