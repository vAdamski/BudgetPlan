import { useContext } from "react";
import { AuthContext } from "../authProvider.jsx";
import { API_URL } from "./apiConfig.jsx";

const useBudgetPlanDetailsApi = () => {
    const { authFetch } = useContext(AuthContext);

    const updateBudgetPlanDetailAllocatedAmount = async (dto) => {
        await authFetch(`${API_URL}/api/budgetPlanDetails/${dto.id}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
                'Accept': 'application/json',
            },
            body: JSON.stringify(dto),
        });
    };

    return {
        updateBudgetPlanDetailAllocatedAmount
    };
}

export default useBudgetPlanDetailsApi;