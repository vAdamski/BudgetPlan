// api/transactionCategories.js
import {useContext} from 'react';
import {API_URL} from './apiConfig.jsx';
import {AuthContext} from "../authProvider.jsx";

const useTransactionCategoriesApi = () => {
    const { authFetch } = useContext(AuthContext);

    const getListTransactionCategories = async () => {
        return await authFetch(`${API_URL}/api/transactionsCategories`);
    };

    const addOverTransactionCategory = async (dto) => {
        return await authFetch(`${API_URL}/api/transactionsCategories/overTransactionCategory`, {
            method: 'POST',
            body: JSON.stringify(dto),
        });
    };

    const addTransactionCategory = async (dto) => {
        return await authFetch(`${API_URL}/api/transactionsCategories/subTransactionCategory`, {
            method: 'POST',
            body: JSON.stringify(dto),
        });
    };

    const deleteTransactionCategory = async (id, migrationId = null) => {
        const queryString = migrationId ? `?id=${id}&migrationId=${migrationId}` : `?id=${id}`;
        return await authFetch(`${API_URL}/api/transactionsCategories/${id}${queryString}`, {
            method: 'DELETE',
        });
    };

    return {
        getListTransactionCategories,
        addOverTransactionCategory,
        addTransactionCategory,
        deleteTransactionCategory,
    };
};

export default useTransactionCategoriesApi;