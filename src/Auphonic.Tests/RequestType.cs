﻿namespace AuphonicNet.Tests
{
	/// <summary>
	/// Provides a enumeration.
	/// </summary>
	public enum RequestType
	{
		Authenticate,
		AuthenticateInvalidClientId,
		AuthenticateInvalidClientSecret,
		AuthenticateInvalidUsername,
		AuthenticateInvalidPassword,

		AccountInfo,
		AccountInfoInvalidToken,
		AccountInfoNullToken,

		Algorithms,
		FileEndings,
		OutputFiles,
		ProductionStatus,
		ServiceTypes,
		Info,

		Production,
		Productions,
		ProductionsUuids,
		DeleteNotFoundProduction,
		DeleteSuccessProduction,
		Preset,
		Presets,
		PresetsUuids,
		DeleteNotFoundPreset,
		DeleteSuccessPreset,

		Services,
		ServiceFiles,
	}
}