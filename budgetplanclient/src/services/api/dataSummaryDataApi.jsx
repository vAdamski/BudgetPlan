import {useContext} from "react";
import {API_URL} from "./apiConfig.jsx";
import {AuthContext} from "../authProvider.jsx";


const useDataSummaryApi = () => {
    const {authFetch} = useContext(AuthContext);

    const fetchCategoryPercentSummary = async (budgetPlanId, budgetPlanBaseId) => {
        if (budgetPlanBaseId == null || budgetPlanBaseId === '')
            return await authFetch(`${API_URL}/api/DataSummary/${budgetPlanId}/categoryPercentSummary`);

        return await authFetch(`${API_URL}/api/DataSummary/${budgetPlanId}/categoryPercentSummary?budgetPlanBaseId=${budgetPlanBaseId}`);
    }

    const fetchExpenseSummary = async (budgetPlanId, budgetPlanBaseId, percent = false) => {
        if (budgetPlanBaseId == null || budgetPlanBaseId === '')
            return await authFetch(`${API_URL}/api/DataSummary/${budgetPlanId}/expenseSummary?percent=${percent}`);

        return await authFetch(`${API_URL}/api/DataSummary/${budgetPlanId}/expenseSummary?budgetPlanBaseId=${budgetPlanBaseId}&percent=${percent}`);
    }

    const fetchIncomeSummary = async (budgetPlanId, budgetPlanBaseId, percent = false) => {
        if (budgetPlanBaseId == null || budgetPlanBaseId === '')
            return await authFetch(`${API_URL}/api/DataSummary/${budgetPlanId}/incomeSummary?percent=${percent}`);

        return await authFetch(`${API_URL}/api/DataSummary/${budgetPlanId}/incomeSummary?budgetPlanBaseId=${budgetPlanBaseId}&percent=${percent}`);
    }

    const fetchLeftMoneySummary = async (budgetPlanId, budgetPlanBaseId) => {
        if (budgetPlanBaseId == null || budgetPlanBaseId === '')
            return await authFetch(`${API_URL}/api/DataSummary/${budgetPlanId}/incomeExpenseSummary`);

        return await authFetch(`${API_URL}/api/DataSummary/${budgetPlanId}/incomeExpenseSummary?budgetPlanBaseId=${budgetPlanBaseId}`);
    }

    return {
        fetchCategoryPercentSummary,
        fetchExpenseSummary,
        fetchIncomeSummary,
        fetchLeftMoneySummary
    }
}

export default useDataSummaryApi;