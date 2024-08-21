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

    return {
        fetchCategoryPercentSummary
    }
}

export default useDataSummaryApi;