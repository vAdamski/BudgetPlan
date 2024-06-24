import {useContext} from 'react';
import {API_URL} from './apiConfig.jsx';
import {AuthContext} from "../authProvider.jsx";

const useTransactionCategoriesApi = () => {
    const { authFetch } = useContext(AuthContext);

    const getListTransactionCategories = async () => {
        return await authFetch(`${API_URL}/api/transactionsCategories`);
    };

    const getSubTransactionCategoriesForBudget = async (budgetId) => {
        return await authFetch(`${API_URL}/api/transactionsCategories/${budgetId}/subTransactionCategories`);
    }

    const addOverTransactionCategory = async (dto) => {
        return await authFetch(`${API_URL}/api/transactionsCategories/overTransactionCategory`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'Accept': 'application/json',
            },
            body: JSON.stringify(dto),
        });
    };

    const addTransactionCategory = async (dto) => {
        return await authFetch(`${API_URL}/api/transactionsCategories/subTransactionCategory`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'Accept': 'application/json',
            },
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
        getSubTransactionCategoriesForBudget,
        addOverTransactionCategory,
        addTransactionCategory,
        deleteTransactionCategory,
    };
};

export default useTransactionCategoriesApi;