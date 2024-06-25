import {useContext} from "react";
import {AuthContext} from "../authProvider.jsx";
import {API_URL} from "./apiConfig.jsx";

const useBudgetPlanBasesApi = () => {
    const {authFetch} = useContext(AuthContext);

    const getBudgetPlanBasesForBudgetPlan = async (budgetPlanId) => {
        return await authFetch(`${API_URL}/api/budgetPlanBases/${budgetPlanId}`);
    }

    return {
        getBudgetPlanBasesForBudgetPlan
    };
}

export default useBudgetPlanBasesApi;