import {useContext} from "react";
import {AuthContext} from "../authProvider.jsx";
import {API_URL} from "./apiConfig.jsx";

const useBudgetPlanBasesApi = () => {
    const {authFetch} = useContext(AuthContext);

    const getBudgetPlanBasesForBudgetPlan = async (budgetPlanId) => {
        return await authFetch(`${API_URL}/api/budgetPlanBases/${budgetPlanId}`);
    }

    const createBudgetPlanBase = async (dateFrom, dateTo, budgetPlanId) => {
        const dto = {
            dateFrom: dateFrom,
            dateTo: dateTo,
            budgetPlanEntityId: budgetPlanId
        }

        console.log(dto);

        return await authFetch(`${API_URL}/api/budgetPlanBases`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(dto)
        });
    }

    const deleteBudgetPlanBase = async (budgetPlanBaseId) => {
        return await authFetch(`${API_URL}/api/budgetPlanBases/${budgetPlanBaseId}`, {
            method: 'DELETE'
        });
    }

    return {
        getBudgetPlanBasesForBudgetPlan,
        createBudgetPlanBase,
        deleteBudgetPlanBase
    };
}

export default useBudgetPlanBasesApi;