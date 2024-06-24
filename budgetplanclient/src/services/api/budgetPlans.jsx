import {useContext} from 'react';
import {API_URL} from './apiConfig.jsx';
import {AuthContext} from "../authProvider.jsx";

const useBudgetPlansApi = () => {
    const { authFetch } = useContext(AuthContext);

    const getBudgetPlans = async () => {
        return await authFetch(`${API_URL}/api/budgetPlans`);
    }

    const getTransactionCategoriesForBudget = async (budgetId) => {
        return await authFetch(`${API_URL}/api/budgetPlans/${budgetId}/transactionCategories`);
    }

    return {
        getBudgetPlans,
        getTransactionCategoriesForBudget
    };
}

export default useBudgetPlansApi;