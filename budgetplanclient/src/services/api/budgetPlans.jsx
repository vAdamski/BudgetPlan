import {useContext} from 'react';
import {API_URL} from './apiConfig.jsx';
import {AuthContext} from "../authProvider.jsx";

const useBudgetPlansApi = () => {
    const {authFetch} = useContext(AuthContext);

    const getBudgetPlans = async () => {
        return await authFetch(`${API_URL}/api/budgetPlans`);
    }

    const getTransactionCategoriesForBudget = async (budgetId) => {
        return await authFetch(`${API_URL}/api/budgetPlans/${budgetId}/transactionCategories`);
    }

    const getBudgetPlanBasesForBudgetPlan = async (budgetPlanId) => {
        return await authFetch(`${API_URL}/api/budgetPlans/${budgetPlanId}/budgetPlanBases`);
    }

    const getBudgetPlanAccessesForBudgetPlan = async (budgetPlanId) => {
        return await authFetch(`${API_URL}/api/budgetPlans/${budgetPlanId}/access`);
    }

    const createBudgetPlan = async (budgetPlan) => {
        return await authFetch(`${API_URL}/api/budgetPlans`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(budgetPlan)
        });
    }

    return {
        getBudgetPlans,
        getTransactionCategoriesForBudget,
        getBudgetPlanBasesForBudgetPlan,
        getBudgetPlanAccessesForBudgetPlan,
        createBudgetPlan
    };
}

export default useBudgetPlansApi;