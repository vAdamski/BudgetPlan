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

    return ({
        createTransactionDetails
    });
}

export default useTransactionDetailsApi;