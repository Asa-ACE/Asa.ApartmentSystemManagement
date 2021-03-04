import { useState } from "react";
import { Link, useParams } from "react-router-dom";
import { apiService } from "../../services/apiService";
import UnitChargeTable from "../UnitChargeTable";

function OwnedUnitCharges() {
  const { buildingId, unitId } = useParams();
  const charges = apiService.getRequest(`unit/owned/${unitId}/charge`);

  return (
    <>
      <UnitChargeTable rows={charges} />
    </>
  );
}

export default OwnedUnitCharges;
